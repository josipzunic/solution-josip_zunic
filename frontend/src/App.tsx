import { Route, Routes } from "react-router-dom";
import { Layout } from "./components/Layout/Layout";
import { routes } from "./constants/routes";
import { ThemeProvider } from "./context/ThemeProvider";
import { Home } from "./pages/Home/Home";
import { ErrorPage } from "./pages/ErrorPage/ErrorPage";
import { ProductDetails } from "./pages/ProductDetails/ProductDetails";

function App() {
  return (
    <ThemeProvider>
      <Layout>
        <Routes>
          <Route path={routes.home} element={<Home />} />
          <Route path={routes.pageNotFound} element={<ErrorPage />} />
          <Route path={routes.productDetails} element={<ProductDetails />} />
        </Routes>
      </Layout>
    </ThemeProvider>
  );
}

export default App;
