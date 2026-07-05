import { useEffect, useState } from "react";
import { useProduct } from "../../hooks/useProduct";
import { productsSearchUrl, productsUrl } from "../../api/products.api";
import { Loader } from "../../components/Loader/Loader";
import { useNavigate, useParams } from "react-router-dom";
import { ProductCard } from "../../components/ProductCard/ProductCard";
import styles from "./ProductDetails.module.css";
import { pageNames } from "../../constants/pageNames";

export const ProductDetails = () => {
  useEffect(() => {
    document.title = pageNames.details;
  }, []);

  const { id } = useParams();
  const [searchTerm] = useState("");
  const url = searchTerm.trim()
    ? productsSearchUrl(searchTerm)
    : productsUrl(id!.toString());
  const { products, loading, error } = useProduct(url);
  const navigate = useNavigate();

  if (loading)
    return (
      <div>
        <Loader />
      </div>
    );
  if (error) return <div> error </div>;
  if (!products) return <div>empty</div>;

  const product = products[0];

  return (
    <section className={styles.details}>
            <div className={styles.arrowContainer}>
        <button className={styles.arrow} onClick={() => navigate(-1)}>
          &#8592; GO BACK
        </button>
      </div>

      <ProductCard product={product} />
    </section>
  );
};
