import { Route, Routes } from "react-router-dom";
import MainLayout from "./layout/main-layout";
import ManufacturerList from "./pages/manufacturers/list";

const App = () => {
  return (
    <Routes>
      <Route element={<MainLayout />}>
        <Route index></Route>
        <Route path="/manufacturers" element={<ManufacturerList />}></Route>
        {/* <Route path="/shoes" element={<ShoeList />}></Route> */}
        {/* <Route path="/colors" element={<ColorList />}></Route> */}
        {/* <Route path="/materials" element={<MaterialList />}></Route> */}
        {/* <Route path="/orders" element={<OrderList />}></Route> */}
      </Route>
    </Routes>
  );
};

export default App;
