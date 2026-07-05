import { NavLink, useNavigate } from "react-router-dom";
import { routes } from "../../constants/routes";
import { useState, type ReactNode } from "react";
import styles from "./Layout.module.css";
import { useLocation } from "react-router-dom";
import { useTheme } from "../../hooks/useTheme";

interface Props {
  children?: ReactNode;
}

export const Layout = ({ children }: Props) => {
  const { lightMode, toggleTheme } = useTheme();
  const location = useLocation();
  const isHome = location.pathname === "/";
  const navigate = useNavigate();
  const [menuOpen, setMenuOpen] = useState(false);

  return (
    <>
      <header
        className={`${styles.header} ${lightMode ? styles.headerLight : styles.headerDark} ${isHome ? styles.headerTransparent : ""}`}
      >
        <h1 className={styles.title} onClick={() => navigate(routes.home)}>
          Academy Task
        </h1>
        <nav className={styles.navbar}>
          <label className={styles.hamburger} htmlFor="navbar-toggle">
            <div
              className={`${styles.bar} ${menuOpen ? styles.barOpen1 : ""}`}
            />
            <div
              className={`${styles.bar} ${menuOpen ? styles.barOpen2 : ""}`}
            />
          </label>
          <input
            type="checkbox"
            id="navbar-toggle"
            className={styles.navToggle}
            checked={menuOpen}
            onChange={() => setMenuOpen(!menuOpen)}
          />
          <div
            className={`${styles.navLinks} ${menuOpen ? styles.navLinksOpen : ""} ${lightMode ? styles.navLinksLight : styles.navLinksDark}`}
          >
            <NavLink
              className={styles.link}
              to={routes.products}
              onClick={() => setMenuOpen(false)}
            >
              Products
            </NavLink>
            <NavLink
              className={styles.link}
              to={routes.likes}
              onClick={() => setMenuOpen(false)}
            >
              Likes
            </NavLink>
            <label className={styles.switch}>
              <input
                type="checkbox"
                checked={!lightMode}
                onChange={toggleTheme}
              />
              <span className={styles.slider}></span>
            </label>
          </div>
        </nav>
      </header>
      <main
        className={`${styles.main} ${isHome ? (lightMode ? styles.mainLight : styles.mainDark) : ""}`}
      >
        {children}
      </main>
    </>
  );
};
