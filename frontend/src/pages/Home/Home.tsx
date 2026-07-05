import styles from "./Home.module.css";
import { pageNames } from "../../constants/pageNames";
import { useEffect } from "react";

export const Home = () => {
  useEffect(() => {
    document.title = pageNames.home;
  }, []);

  return <div className={styles.home}>PLACEHOLDER TEXT</div>;
};
