import Main from "./components/Pages/Main";
import Warehouse from "./components/Pages/Warehouse";

const AppRoutes = [
  {
    index: true,
    element: <Main />
  },
  {
    path: '/warehouse',
    element: <Warehouse />
  }
];

export default AppRoutes;
