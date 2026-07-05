import type { Product } from "../../constants/types";

type Props = {
  product: Product;
};

export const ProductCard = ({ product }: Props) => {
  return (
    <div>
      <img src={product.imageUrl} />
      <h3>{product.name}</h3>
      <h2>{product.price}</h2>
      <p>{product.description}</p>
    </div>
  );
};
