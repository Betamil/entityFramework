import {Component} from "react";

export class Categories extends Component {
    static displayName = Categories.name;

    constructor(props) {
        super(props);
        this.state = { categories: [], loading: true };
    }

    componentDidMount() {
        this.allCategories();
    }


    static renderCategoriesTable(categories) {
        return (
            <table className="table table-striped" aria-labelledby="tableLabel">
                <thead>
                <tr>
                    <th>Identifiant</th>
                    <th>Nom</th>
                    <th>Description</th>
                    <th>Photo</th>
                </tr>
                </thead>
                <tbody>
                {categories.map(categories =>
                    <tr>
                        <td>{categories.id}</td>
                        <td>{categories.categoryName}</td>
                        <td>{categories.description}</td>
                        <td>{categories.picture}</td>
                    </tr>
                )}
                </tbody>
            </table>
        );
    }

    render() {
        let contents = this.state.loading
            ? <p><em>Loading...</em></p>
            : Categories.renderCategoriesTable(this.state.categories);

        return (
            <div>
                <h1 id="tableLabel">Categories</h1>
                <p>This component demonstrates fetching categories from the server.</p>
                {contents}
            </div>
        );
    }

     async allCategories() {
        const response = await fetch('Category');
        const data = await response.json();
        this.setState({ categories: data, loading: false });
    }
}


export const AllCategories = async () => {
    const response = await fetch('Category');
    const data = await response.json();
    return data;
}