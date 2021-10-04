import React from "react";
import styles from "./Header.module.scss";

import logo from "../../icons/logo.svg";
import profile from "../../icons/profile.svg";

const Header = () => {
  return (
    <header className={styles.header}>
      <div className={styles.wrap}>
        <img src={logo} alt="logo" />
        <nav className={styles.nav}>
          <ul className={styles.navList}>
            <li className={styles.listItem}>
              <a className={styles.listItemLink} href="/">
                Мойка
              </a>
            </li>
            <li className={styles.listItem}>
              <a className={styles.listItemLink} href="/">
                Стать партнером
              </a>
            </li>
            <li className={styles.listItem}>+7 937 247 77 77</li>
          </ul>
        </nav>
        <a href="/">
          <img src={profile} alt="profile" />
        </a>
      </div>
    </header>
  );
};

export default Header;
