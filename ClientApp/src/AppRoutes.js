import Main from "./components/Pages/Main";
import Warehouse from "./components/Pages/Warehouse";
import SpacePage from "./components/Pages/SpacePage";

const AppRoutes = [
  {
    index: true,
    element: <Main />
  },
  {
    path: '/Warehouse',
    element: <Warehouse />
  },
  {
    path: '/Warehouse/Space/:spaceName',
    element: <SpacePage />
  }
];

export default AppRoutes;
