import { Home } from "./components/Home";
import { Categories } from "./components/Category/Categories";
import { AddCategory } from "./components/Category/AddCategory";
import { Products } from "./components/Product/Products";


const AppRoutes = [
    {
        index: true,
        element: <Home />
    },
    {
        path: '/categories',
        element: <Categories />
    },
    {
        path: '/addCategory',
        element: <AddCategory />
    },
    {
        path: '/products',
        element: <Products />
    }
];

export default AppRoutes;
