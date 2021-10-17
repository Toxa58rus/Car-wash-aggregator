import React, { useState } from "react";

import Modal from "../Modal/Modal";
import Button from "../Button/Button";
import Review from "../Review/Review";
import styles from "./OrderCard.module.scss";

import {
  ORDERS_STATUS,
  ORDERS_STATUS_NAMES,
} from "../../constants/ORDER-STATUS";

const OrderCard = ({ status }) => {
  const [modalIsOpen, toggleModal] = useState(false);

  const closeReviewModal = () => {
    toggleModal(false);
  };

  const openReviewModal = () => {
    toggleModal(true);
  };

  return (
    <div className={styles.contain}>
      {modalIsOpen && (
        <Modal onClose={closeReviewModal} label="Оставте свой отзыв">
          <Review />
        </Modal>
      )}
      <div className={styles.innerFlex}>
        <h3>Name car wash</h3>
        <div className={styles.phoneCarWash}>
          <span>Телефон мойки:</span>+7 (777)-777-77-77
        </div>
      </div>
      <div className={styles.innerFlex}>
        <div className={styles.info}>
          <div className={styles.infoItem}>
            <span>Город:</span> Город
          </div>
          <div className={styles.infoItem}>
            <span>Адрес:</span> Адрес
          </div>
          <div className={styles.infoItem}>
            <span>Дата:</span> Дата
          </div>
          <div className={styles.infoItem}>
            <span>Время:</span> Время
          </div>
        </div>
        <div className={styles.orderActions}>
          {status === ORDERS_STATUS.BOOKED && (
            <>
              <div className={styles.status}>
                <span>Статус:</span>
                {ORDERS_STATUS_NAMES[status]}
              </div>
              <Button size="maxWidth" className={styles.cancelBtn}>
                Отменить
              </Button>
            </>
          )}
          {(status === ORDERS_STATUS.FINISHED ||
            status === ORDERS_STATUS.CANCELED) && (
            <>
              <div className={styles.status}>
                <span>Статус:</span>
                {ORDERS_STATUS_NAMES[status]}
              </div>
              <Button
                size="maxWidth"
                className={styles.reviewBtn}
                onClick={openReviewModal}
              >
                Оставить отзыв
              </Button>
            </>
          )}
        </div>
      </div>
    </div>
  );
};

export default OrderCard;
