import { Route, Routes } from "react-router-dom";
import { Layout } from "./components/Layout/Layout";
import { routes } from "./constants/routes";
import { ThemeProvider } from "./context/ThemeProvider";
import { Home } from "./pages/Home/Home";

function App() {
  return (
    <ThemeProvider>
      <Layout>
        <Routes>
          <Route path={routes.home} element={<Home />} />
        </Routes>
      </Layout>
    </ThemeProvider>
  );
}

export default App;
