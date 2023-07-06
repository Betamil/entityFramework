import { Component } from "react";
import GetProduct from "./GetProduct";
const initialState = {
    productName: '',
    supplierId: '',
    categoryId: '',
    quantityPerUnit: '',
    unitPrice: '',
    unitsInStock: '',
    unitsOnOrder: '',
}


export class AddProduct extends Component {

    constructor(props) {
        super(props);
        this.state = this.initialState;

        this.handleChange = this.handleChange.bind(this);
        this.handleSubmit = this.handleSubmit.bind(this);
    }

    handleChange(e) {
        if (e.target.id === 'productName') {
            this.setState({ productName: e.target.value });
        } else if (e.target.id === 'supplierName') {
            this.setState({ supplierId: e.target.value });
        } else if (e.target.id === 'quantiteUnitaire') {
            this.setState({ quantityPerUnit: e.target.value });
        } else if (e.target.id === 'prix') {
            this.setState({ unitPrice: e.target.value });
        } else if (e.target.id === 'quantiteEnStock') {
            this.setState({ unitsInStock: e.target.value });
        } else if (e.target.id === 'quantiteAchat') {
            this.setState({ unitsOnOrder: e.target.value });
        }
    }

    handleSubmit(event) {
        const product = {
            productName: this.state.productName,
            supplierId: this.state.supplierId,
            categoryId: this.state.categoryId,
            quantityPerUnit: this.state.quantityPerUnit,
            unitPrice: this.state.unitPrice,
            unitsInStock: this.state.unitsInStock,
            unitsOnOrder: this.state.unitsOnOrder,
        }
        this.createProduct(product);
    }

    getCategoryIdHandler = (id) => {
        this.setState({ categoryId: id });
    }

    render() {
        return (
            <form onSubmit={this.handleSubmit}>
                <label>
                    Nom du produit :
                    <input type="text" id="productName" onChange={this.handleChange} />
                </label>
                <br />
                <GetProduct sendCategoryId={this.getCategoryIdHandler} />
                <br />
                <label>
                    Quantité unitaire:
                    <input type="text" id="quantiteUnitaire" onChange={this.handleChange} />
                </label>
                <br />
                <label>
                    Prix:
                    <input type="text" id="prix" onChange={this.handleChange} />
                </label>
                <br />
                <label>
                    Quantité en stock:
                    <input type="number" id="quantiteEnStock" onChange={this.handleChange} />
                </label>
                <br />
                <label>
                    Quantité à l'achat:
                    <input type="number" id="quantiteAchat" onChange={this.handleChange} />
                </label>
                <br />
                <input type="submit" value="Enregistrer" />
            </form >
        );
    }

    async createProduct(data) {
        await fetch('api/Product', {
            method: 'POST',
            body: JSON.stringify(data),
            headers: {
                'Content-Type': 'application/json'
            }
        }).then(response => {
            console.warn(data)
            if (response.status >= 200 && response.status < 300) {
                return response
            } else {
                console.log('Somthing happened wrong');
            }
        }).catch(err => err);
    }


}