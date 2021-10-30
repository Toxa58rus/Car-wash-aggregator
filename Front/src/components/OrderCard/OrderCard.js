import React, { useEffect, useState } from "react";
import api from "../../lib/api";
import sources from "../../helpers/sources";
import { useDispatch, useSelector } from "react-redux";
import { selectSession, setSession } from "../../state/session";
import { STATUSES, STATUSES_NAMES } from "../../constants/STATUSES";
import Spinner from "../Spinner/Spinner";
import { formattDataTime } from "../../helpers/dateFormatter";
import { toast } from "react-toastify";
import { selectConstants } from "../../state/constants";

import Modal from "../Modal/Modal";
import Button from "../Button/Button";
import Review from "../Review/Review";
import styles from "./OrderCard.module.scss";

const OrderCard = ({ udateOrders, item }) => {
  const [modalIsOpen, toggleModal] = useState(false);
  const [state, setState] = useState({ data: null, isLoading: true });
  const { id, carWashId, status, dateReservation } = item;
  const user = useSelector(selectSession);
  const constants = useSelector(selectConstants);
  const dispatch = useDispatch();

  const city = constants.cities.reduce((city) => city.name === user.city);

  const closeReviewModal = () => {
    toggleModal(false);
  };

  const openReviewModal = () => {
    toggleModal(true);
  };

  const getCarWash = () => {
    api
      .get(sources.carWash(carWashId))
      .then((response) => {
        setState({
          data: response.data,
          isLoading: false,
        });

        if (response.user) {
          dispatch(setSession(response.user));
        }
      })
      .catch(() => toast.error("Error car washes"));
  };

  useEffect(() => {
    if (state.isLoading) {
      getCarWash();
    }
  });

  const cancelOrder = () => {
    api
      .put(sources.orderStatuses, { status: STATUSES.CANCELED, id: id })
      .then((response) => {
        if (response.status === 200) {
          toast.success("Бронь отменена");
        }

        udateOrders();

        if (response.user) {
          dispatch(setSession(response.user));
        }
      })
      .catch((err) => toast.error(err.data.message));
  };

  return (
    <div className={styles.contain}>
      {modalIsOpen && (
        <Modal onClose={closeReviewModal} label="Оставте свой отзыв">
          <Review
            closeReviewModal={closeReviewModal}
            carWashId={carWashId}
            userId={user.id}
          />
        </Modal>
      )}
      {state.isLoading ? (
        <Spinner center />
      ) : (
        <>
          <div className={styles.innerFlex}>
            <h3>{state.data.name}</h3>
            <div className={styles.phoneCarWash}>
              <span>Телефон мойки:</span>
              {state.data.phone}
            </div>
          </div>
          <div className={styles.innerFlex}>
            <div className={styles.info}>
              <div className={styles.infoItem}>
                <span>Город:</span> {city.name}
              </div>
              <div className={styles.infoItem}>
                <span>Адрес:</span> {state.data.address}
              </div>
              <div className={styles.infoItem}>
                <span>Дата:</span> {formattDataTime(dateReservation)}
              </div>
            </div>
            <div className={styles.orderActions}>
              {status === STATUSES.BOOKED && (
                <>
                  <div className={styles.status}>
                    <span>Статус:</span>
                    {STATUSES_NAMES[status]}
                  </div>
                  <Button
                    size="maxWidth"
                    className={styles.cancelBtn}
                    increased
                    onClick={cancelOrder}
                  >
                    Отменить
                  </Button>
                </>
              )}
              {(status === STATUSES.COMPLETED ||
                status === STATUSES.CANCELED) && (
                <>
                  <div className={styles.status}>
                    <span>Статус:</span>
                    {STATUSES_NAMES[status]}
                  </div>
                  {status === STATUSES.COMPLETED && (
                    <Button size="maxWidth" increased onClick={openReviewModal}>
                      Оставить отзыв
                    </Button>
                  )}
                </>
              )}
            </div>
          </div>
        </>
      )}
    </div>
  );
};

export default OrderCard;
