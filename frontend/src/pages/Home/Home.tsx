import styles from "./Home.module.css";
import { pageNames } from "../../constants/pageNames";
import { useEffect, useState } from "react";
import { Loader } from "../../components/Loader/Loader";
import { ProductCard } from "../../components/ProductCard/ProductCard";
import { useProduct } from "../../hooks/useProduct";
import { Filters } from "../../components/Filters/Filters";
import { Link } from "react-router-dom";
import { routes } from "../../constants/routes";
import { productsSearchUrl, productsUrl } from "../../api/products.api";

export const Home = () => {
  useEffect(() => {
    document.title = pageNames.home;
  }, []);

  const [searchTerm, setSearchTerm] = useState("");
  const url = searchTerm.trim() ? productsSearchUrl(searchTerm) : productsUrl();
  const { products, loading, error } = useProduct(url);
  const handleSearch = (searchTerm: string) => {
    setSearchTerm(searchTerm);
  };

  if (loading)
    return (
      <div>
        <Loader />
      </div>
    );
  if (error) return <div> error </div>;
  if (!products) return <div>empty</div>;

  return (
    <section className={styles.home}>
      <Filters onSearch={handleSearch} />
      {products.map((product) => (
        <Link
          className={styles.link}
          to={routes.productDetails.replace(":id", product.id.toString())}
        >
          <ProductCard product={product} key={product.id} />
        </Link>
      ))}
    </section>
  );
};
