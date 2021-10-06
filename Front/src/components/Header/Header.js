import React, { useState } from "react";
import cn from "classnames";
import routes from "../../helpers/routes";

import Button from "../Button/Button";
import styles from "./Header.module.scss";

import logo from "../../icons/logo.svg";
import profile from "../../icons/profile.svg";
import phoneIcon from "../../icons/phone.svg";
import menuIcon from "../../icons/menu.svg";
import closeIcon from "../../icons/close.svg";
import arrowRight from "../../icons/arrow-right.svg";

const Header = () => {
  const [mobileMenu, setMobileMenu] = useState(false);

  const handleOpenMobileMenu = () => {
    setMobileMenu(true);
  };
  const handleCloseMobileMenu = () => {
    setMobileMenu(false);
  };

  const navCn = cn(styles.nav, {
    [styles.activeMobileMenu]: Boolean(mobileMenu),
  });
  return (
    <header className={styles.header}>
      <div className={styles.wrap}>
        <Button
          className={cn(styles.mobileNavBtn, styles.mobile)}
          onClick={handleOpenMobileMenu}
          variant="square"
        >
          <img src={menuIcon} alt="menu" />
        </Button>
        <a href={routes.root}>
          <img src={logo} alt="logo" />
        </a>
        <nav className={navCn}>
          <Button
            className={cn(styles.mobileNavBtn, styles.mobile, styles.closeBtn)}
            onClick={handleCloseMobileMenu}
            variant="square"
          >
            <img src={closeIcon} alt="close menu" />
          </Button>
          <ul className={styles.navList}>
            <li className={styles.listItem}>
              <a className={styles.listItemLink} href={routes.root}>
                Мойка
                <img src={arrowRight} alt="icon" className={styles.mobile} />
              </a>
            </li>
            <li className={cn(styles.listItem, styles.mobile)}>
              <a className={styles.listItemLink} href={routes.profile}>
                Профиль
                <img src={arrowRight} alt="icon" className={styles.mobile} />
              </a>
            </li>
            <li className={styles.listItem}>
              <img src={phoneIcon} alt="phone" />
              +7 937 247 77 77
            </li>
          </ul>
        </nav>
        <a href={routes.login}>
          <img src={profile} alt="profile" />
        </a>
      </div>
    </header>
  );
};

export default Header;
