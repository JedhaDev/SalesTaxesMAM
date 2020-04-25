import React from 'react';
import $ from 'jquery';
//import select2 from 'react-select2'; 
import Header from './Header';
//import {Row, Col, Input, Button, Icon} from 'react-materialize'
import { Row, Col, Input, Button } from 'react-bootstrap';

export default class ProductsManagement extends React.Component {
    constructor() {
        super();
        this.state = {
            inputList: [],
            productList: [],
            //productList:[
            //    {"id":3, "name":"Live Chicken","rate":0},
            //    {"id":4, "name":"Cooked Chicken","rate":5},
            //    {"id":5, "name":"Freez Chicken","rate":12},
            //    {"id":6, "name":"Live Goats","rate":0},
            //    {"id":7, "name":"Cooked Goats","rate":12},
            //    {"id":8, "name":"Fry Goats","rate":18}
            //],
            products: [
                { "id": 3, "name": "product", "rate": 0, "price": '0', "taxAmount": '0', "total": 0},
            ],
            total: 0,
            taxTotal: 0,
            selectedProducts: [],

        };

        fetch('https://localhost:44364/api/product/getProducts')
            .then(response => response.json())
            .then(data => {
                this.setState({ productList: data.result, loading: false });
                console.log(this.state.productList);
            });

        this.componentDidMount = this.componentDidMount.bind(this);
        //this.componentDidUpdate = this.componentDidUpdate.bind(this);
    }
    addNewRow(i, event) {
        let count = this.state.products.length;
        if (count == i + 1) {
            this.onAddBtnClick(event);
        }
    }
    componentDidMount(event) {
        this.refs.pro0.focus();
    }


    onAddBtnClick(event) {
        let newProducts = { "id": "", "name": "", "rate": 0, "price": '', "taxAmount": '', "total": 0 };
        let products = this.state.products;
        products.push(newProducts);
        this.setState({ products: products });
    }

    handleChangeProducts(i, event) {
        let row = this.state.products;
        let productList = this.state.productList;

        for (var j = 0; j <= productList.length; j++) {
            if (productList[j].name == event.target.value) {
                row[i].id = productList[j].id;
                row[i].name = productList[j].name;

                row[i].price = productList[j].price.toFixed(2);
                row[i].taxAmount = productList[j].taxAmount.toFixed(2);
                let taxesTotal = ' ';
                for (var x = 0; x < productList[j].taxes.length; x++) {
                    taxesTotal += ' ' + productList[j].taxes[x].percent + '% +';
                }
                row[i].rate = taxesTotal.substring(0, taxesTotal.length - 1);
                row[i].total = (productList[j].price + productList[j].taxAmount).toFixed(2);
                this.setState({ products: row });
                break;
            }
        }

        let newRow = this.state.products;
        if (newRow[i].price != '') {
            this.setState({ products: newRow });
        }
        this.updateSubtotal();
    }

    updateSubtotal() {
        let total = 0;
        let taxTotal = 0;

        for (var i = 0; i < this.state.products.length; i++) {
            if (this.state.products[i].total != "") {
                total = parseFloat(parseFloat(total) + parseFloat(this.state.products[i].total));
                taxTotal = parseFloat(parseFloat(taxTotal) + parseFloat(this.state.products[i].taxAmount));
            }
        }

        this.setState({ total: total.toFixed(2), taxTotal: taxTotal.toFixed(2) });

    }

    updatePrice(i, rate, event) {
        let row = this.state.products;
        let per = (parseFloat(event.target.value) * rate) / 100;
        row[i].price = event.target.value;
        row[i].taxAmount = ((parseFloat(event.target.value) * rate) / 100).toFixed(2);
        row[i].total = (per + (parseFloat(event.target.value))).toFixed(2);
        this.setState({ products: row });

        this.updateSubtotal();
    }

    removeProducts(i, event) {
        let row = this.state.products;
        row.splice(i, 1);
        this.setState({ products: row });
        this.updateSubtotal();
    }

    render() {
        return (
            <div>
                <div className="row">
                    <Header title="Sales Portal" />
                </div>
                <div className="row">
                    <div className="panel panel-default sales-content">
                        <div className="row border">
                            <div className="panel-heading col-md-1">Action</div>
                            <div className="panel-heading col-md-1">Item</div>
                            <div className="panel-heading col-md-3">Products</div>
                            <div className="panel-heading col-md-2 text-center">Tax (%)</div>
                            <div className="panel-heading col-md-2 text-center">Tax on price ($)</div>
                            <div className="panel-heading col-md-1 text-center">Price</div>
                            <div className="panel-heading col-md-2 text-center">Price w/Tax</div>
                        </div>
                        <div className="sales-content" id="rowList">
                            {this.state.products.map(function (item, i) {
                                return (
                                    <Row>
                                        <div className="col-md-1 form-group cursor-pointer red" onClick={this.removeProducts.bind(this, i)}>X</div>
                                        <div className="col-md-1 form-group" >{i + 1}</div>
                                        <div className="col-md-3 form-group">
                                            <select value={item.name} className="form-control js-example-basic-single" ref={'pro' + i} onChange={this.handleChangeProducts.bind(this, i)}>
                                                <option value="" label="">
                                                </option>
                                                {this.state.productList.map(function (product, j) {
                                                    return (
                                                        <option value={product.name} label={product.name}>
                                                        </option>
                                                    )
                                                })}
                                            </select>
                                        </div>

                                        <div className="col-md-2 form-group text-center">{item.rate}</div>

                                        <div className="col-md-2 form-group text-center">{item.taxAmount}</div>
                                        <div className="col-md-1 form-group text-center">{item.price}</div>
                                        <div className="col-md-2 form-group text-center">{item.total}</div>
                                    </Row>
                                )
                            }, this)}

                        </div>
                        <div className="row panel-footer">

                            <div className="row sales-content">
                                <div className="col-md-12 form-group text-left">
                                    <Button onClick={this.onAddBtnClick.bind(this)}>New Row</Button>
                                </div>
                            </div>
                            <div className="row sales-content">
                                <div className="col-md-7 form-group text-center">&nbsp;</div>
                                <div className="col-md-2 form-group text-center">Sales Taxes: {this.state.taxTotal}</div>
                                <div className="col-md-2 form-group text-center">Total: {this.state.total}</div>
                                <div className="col-md-1 form-group text-center">&nbsp;</div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        );
    }
}