import { Home } from "./components/Home";
import { Categories } from "./components/Categories";
import { AddCategory } from "./components/AddCategory";


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
    }
];

export default AppRoutes;
