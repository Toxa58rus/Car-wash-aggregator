import React from "react";
import routes from "../../helpers/routes";
import { useSelector } from "react-redux";
import { selectSession } from "../../state/session";

import vector from "../../icons/location.svg";
import car from "../../icons/car.svg";

import RateStars from "../RateStars/RateStars";
import Button from "../Button/Button";
import styles from "./WashCard.module.scss";
import { ROLES } from "../../constants/ROLES";

const WashCard = ({ id, item }) => {
  const { name, description, adress, pic, availability, category } = item;
  const session = useSelector(selectSession);

  return (
    <div className={styles.Card}>
      <a href={routes.carWash(id)} className={styles.wrap}>
        <img className={styles.imgPlaceholder} src={pic} alt="Мойка" />
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
        <span className={styles.cardAdressText}> {adress}</span>
      </div>
      <div className={styles.rating}>
        <span className={styles.ratingLabel}>Рэйтинг:</span>{" "}
        <RateStars edit={false} />
      </div>
      <div className={styles.carCategoties}>
        <span>Категории автомобилей:</span>
        {category.map((i) => ` ${i} `)}
      </div>

      {session && session.role === ROLES.CLIENT && (
        <>
          <div className={styles.cardAvailability}>
            <img src={car} alt="car" />
            <span className={styles.cardAvailabilityText}>
              {availability} мест свободно
            </span>
          </div>

          <Button className={styles.washCardButton} size="maxWidth">
            Забронировать
          </Button>
        </>
      )}
    </div>
  );
};

export default WashCard;
