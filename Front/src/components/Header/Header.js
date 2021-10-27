import React, { useState } from "react";
import cn from "classnames";
import routes from "../../helpers/routes";
import { selectSession, setSession } from "../../state/session";
import { useDispatch, useSelector } from "react-redux";
import { ROLES } from "../../constants/ROLES";
import { removeUserCookie } from "../../lib/cookie";
import { useHistory } from "react-router";

import Button from "../Button/Button";
import styles from "./Header.module.scss";

import logo from "../../icons/logo.svg";
import profile from "../../icons/profile.svg";
import user from "../../icons/user.svg";
import phoneIcon from "../../icons/phone.svg";
import menuIcon from "../../icons/menu.svg";
import closeIcon from "../../icons/close.svg";
import arrowRight from "../../icons/arrow-right.svg";
import backIcon from "../../icons/arrow-back.svg";

const Header = () => {
  const [mobileMenu, setMobileMenu] = useState(false);
  const session = useSelector(selectSession);
  const role = session && session.role;
  const dispatch = useDispatch();
  const history = useHistory();

  const handleOpenMobileMenu = () => {
    setMobileMenu("mobileMenu");
  };
  const handleCloseMobileMenu = () => {
    setMobileMenu(false);
  };
  const handleOpenMobileSubMenu = () => {
    setMobileMenu("mobileSubMenu");
  };

  const logOut = () => {
    removeUserCookie();
    dispatch(setSession(null));
    history.push(routes.root);
  };

  const profileLink = !session ? routes.login : routes.profileSettings;
  const profileIMG = !session ? profile : user;

  const navCn = cn(styles.nav, {
    [styles.activeMobileMenu]:
      mobileMenu === "mobileMenu" || mobileMenu === "mobileSubMenu",
  });

  const sublistCn = cn(styles.mobileMenuSublist, {
    [styles.sublistActive]: mobileMenu === "mobileSubMenu",
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
            <li className={styles.listItem}>
              <Button
                className={styles.profileBtn}
                size="maxWidth"
                onClick={handleOpenMobileSubMenu}
              >
                <div className={styles.btnInner}>
                  Профиль{" "}
                  <img src={arrowRight} alt="icon" className={styles.mobile} />
                </div>
              </Button>
            </li>

            {session &&
              (session.role === ROLES.PARTNER ||
                session.role === ROLES.CLIENT) && (
                <ul className={sublistCn}>
                  <li className={styles.sublistItem}>
                    <Button
                      className={styles.closeSublistBtn}
                      size="maxWidth"
                      onClick={handleOpenMobileMenu}
                    >
                      <div className={styles.closeBtnInner}>
                        <img src={backIcon} alt="icon" />
                        Профиль
                      </div>
                    </Button>
                  </li>
                  <li className={styles.sublistItem}>
                    <a
                      className={styles.listItemLink}
                      href={routes.profileSettings}
                    >
                      Настройки профиля
                      <img
                        src={arrowRight}
                        alt="icon"
                        className={styles.mobile}
                      />
                    </a>
                  </li>
                  <li className={styles.sublistItem}>
                    <a
                      className={styles.listItemLink}
                      href={routes.profileOrders}
                    >
                      Заказы
                      <img
                        src={arrowRight}
                        alt="icon"
                        className={styles.mobile}
                      />
                    </a>
                  </li>
                  {role === ROLES.PARTNER && (
                    <li className={styles.sublistItem}>
                      <a
                        className={styles.listItemLink}
                        href={routes.profileCarWashes}
                      >
                        Мойки
                        <img
                          src={arrowRight}
                          alt="icon"
                          className={styles.mobile}
                        />
                      </a>
                    </li>
                  )}
                  <li className={styles.sublistItem}>
                    <Button
                      className={styles.logOut}
                      size="maxWidth"
                      onClick={logOut}
                    >
                      <div className={styles.listItemLink}>
                        Выход
                        <img
                          src={arrowRight}
                          alt="icon"
                          className={styles.mobile}
                        />
                      </div>
                    </Button>
                  </li>
                </ul>
              )}

            <li className={styles.listItem}>
              <img src={phoneIcon} alt="phone" />
              +7 937 247 77 77
            </li>
          </ul>
        </nav>
        <a href={profileLink}>
          <img src={profileIMG} alt="profile" />
        </a>
      </div>
    </header>
  );
};

export default Header;
