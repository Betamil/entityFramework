import { Component } from "react";

const initialState = {
    categoryName: '',
    description: '',
    picture: ''
}

export class AddCategory extends Component {

    constructor(props) {
        super(props);
        this.state = this.initialState;

        this.handleChange = this.handleChange.bind(this);
        this.handleSubmit = this.handleSubmit.bind(this);
    }

    handleChange(e) {
        if (e.target.id === 'categoryName') {
            this.setState({ categoryName: e.target.value });
        } else if (e.target.id === 'description') {
            this.setState({ description: e.target.value });
        } else if (e.target.id === 'picture') {
            this.setState({ picture: e.target.value });
        }
    }

    handleSubmit(event) {
        const category = {
            categoryName: this.state.categoryName,
            description: this.state.description,
            picture: this.state.picture
        }
        this.createCategory(category);
    }

    render() {
        return (
            <form onSubmit={this.handleSubmit}>
                <label>
                    Nom de la catégorie:
                    <input type="text" id="categoryName" onChange={this.handleChange} />
                </label>
                <br />
                <label>
                    Description:
                    <input type="text" id="description" onChange={this.handleChange} />
                </label>
                <br />
                <label>
                    Photo:
                    <input type="text" id="picture" onChange={this.handleChange} />
                </label>
                <br />
                <input type="submit" value="Submit" />
            </form >
        );
    }

    async createCategory(data) {
    await fetch('Category', {
        method: 'POST',
        body: JSON.stringify(data),
        headers: {
            'Content-Type': 'application/json'
        }
    }).then(response => {
        if (response.status >= 200 && response.status < 300) {
            return response;
            console.log(response);
            window.location.reload();
        } else {
            console.log('Somthing happened wrong');
        }
    }).catch(err => err);
}
}