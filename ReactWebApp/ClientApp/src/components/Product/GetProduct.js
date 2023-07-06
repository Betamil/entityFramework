import React, { useEffect, useState } from "react";
import { AllCategories } from "./../Category/Categories";

function GetProduct({ sendCategoryId }) {
    const [values, setValues] = useState([])
    const [options, setOptions] = useState()
    const [selectedId, setSelectedId] = useState(0); 

    useEffect(() => {
        AllCategories().then((val) => setValues(val));
    }, [])

    const selectChangeHandler = (e) => {
        setSelectedId(e.target.value)
        sendCategoryId(e.target.value)
    }
    return (
        <div>
            <label>
                Nom de la catégorie:
                <select id="categoryName" onChange={selectChangeHandler}>
                    {
                        values.map((opts, i) => <option key={i} value={opts.id}>{opts.categoryName}</option>)
                    }
                </select>
            </label>
        </div>
    );
}

export default GetProduct;