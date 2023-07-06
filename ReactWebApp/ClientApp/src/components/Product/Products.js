
import { Component } from "react";

export class Products extends Component {
    static displayName = Products.name;

    constructor(props) {
        super(props);
        this.state = { products: [], loading: true };
    }

    componentDidMount() {
        this.allProducts();
    }


    static renderProductsTable(products) {
        return (
            <table className="table table-striped" aria-labelledby="tableLabel">
                <thead>
                    <tr>
                        <th>Identifiant</th>
                        <th>Nom</th>
                        <th>Categorie</th>
                        <th>Quantité unitaire</th>
                        <th>Prix</th>
                        <th>Quantité en stock</th>
                        <th>Quantité à l'achat'</th>
                    </tr>
                </thead>
                <tbody>
                    {products.map(products =>
                        <tr>
                            <td>{products.id}</td>
                            <td>{products.productName}</td>
                            <td>{products.category.categoryName}</td>
                            <td>{products.quantityPerUnit}</td>
                            <td>{products.unitPrice}</td>
                            <td>{products.unitsInStock}</td>
                            <td>{products.unitsOnOrder}</td>
                        </tr>
                    )}
                </tbody>
            </table>
        );
    }

    render() {
        let contents = this.state.loading
            ? <p><em>Loading...</em></p>
            : Products.renderProductsTable(this.state.products);

        return (
            <div>
                <h1 id="tableLabel">Products</h1>
                <p>This component demonstrates fetching products from the server.</p>
                {contents}
            </div>
        );
    }

    async allProducts() {
        const response = await fetch('api/Product');
        const data = await response.json();
        this.setState({ products: data, loading: false });
    }
}
