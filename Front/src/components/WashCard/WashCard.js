import React from "react";
import routes from "../../helpers/routes";
import { useSelector } from "react-redux";
import { selectSession } from "../../state/session";

import vector from "../../icons/location.svg";

import RateStars from "react-rating-stars-component";
import styles from "./WashCard.module.scss";
import { ROLES } from "../../constants/ROLES";
import { CAR_CATEGORIES_NAMES } from "../../constants/CAR-CATEGORIES";

const WashCard = ({ id, item }) => {
  const { name, description, address, rate, carCategories, img } = item;
  const session = useSelector(selectSession);
  const role = !session ? null : session.role;

  const isNumber = (value) => {
    if (typeof value === "string") {
      const arr = value.split(",");
      const str = arr.join(".");
      return +str;
    } else {
      return value;
    }
  };

  return (
    <div className={styles.Card}>
      <a href={routes.carWash(id)} className={styles.wrap}>
        <img className={styles.imgPlaceholder} src={img} alt="Мойка" />
      </a>
      <a href={routes.carWash(id)} className={styles.wrap}>
        <span className={styles.cardName}> {name} </span>
      </a>
      <div className={styles.cardDesc}>
        <span> {description} </span>
        <a href={routes.carWash(id)} className={styles.cardDescFull}>
          Подробнее
        </a>
      </div>
      <div className={styles.cardAdress}>
        <img src={vector} alt="location" />
        <span className={styles.cardAdressText}>{address}</span>
      </div>
      <div className={styles.rating}>
        <span className={styles.ratingLabel}>Рэйтинг:</span>{" "}
        <RateStars edit={false} value={isNumber(rate)} size={25} />
      </div>
      <div className={styles.carCategoties}>
        <span>Категории автомобилей:</span>
        {carCategories.map((i) => (
          <span>{CAR_CATEGORIES_NAMES[i]}</span>
        ))}
      </div>

      {role !== ROLES.PARTNER && (
        <a href={routes.carWash(id)} className={styles.washLink}>
          Забронировать
        </a>
      )}
    </div>
  );
};

export default WashCard;
