import React, { useState } from "react";
import { Form, Field } from "react-final-form";
import { toast } from "react-toastify";

import RateStars from "../RateStars/RateStars";
import Button from "../Button/Button";
import styles from "./Review.module.scss";
import api from "../../lib/api";
import sources from "../../helpers/sources";
import { useDispatch } from "react-redux";
import { setSession } from "../../state/session";

const Review = ({ carWashId, userId, closeReviewModal }) => {
  const [rate, setRate] = useState();
  let currentForm = null;
  const dispatch = useDispatch();

  const handleRateChange = (value) => {
    setRate(value);
    currentForm.change("rating", value);
  };

  const sendReview = (values) => {
    api
      .post(sources.getReview, {
        ...values,
        carWashId: carWashId,
        userId: userId,
      })
      .then((response) => {
        if (response.status === 200) {
          toast.success("Ваш коментарий опубликован");
          closeReviewModal();
        }

        if (response.user) {
          dispatch(setSession(response.user));
        }
      })
      .catch((err) => toast.error(err.data.message));
  };

  return (
    <div className={styles.contain}>
      <div className={styles.title}>Оставте свой отзыв</div>
      <Form
        onSubmit={sendReview}
        render={({ handleSubmit, form }) => {
          currentForm = form;
          return (
            <form onSubmit={handleSubmit}>
              <div className={styles.inner}>
                <Field
                  name="rating"
                  render={({ input, meta }) => (
                    <div className={styles.rate}>
                      <RateStars
                        {...input}
                        meta={meta}
                        size={40}
                        onChange={handleRateChange}
                      />
                      <span>Оцените это заведение *</span>
                    </div>
                  )}
                />
              </div>
              <Field
                name="Message"
                render={({ input, meta }) => (
                  <textarea
                    className={styles.textarea}
                    placeholder="Чтыбы вы хотели рассказать о данном заведении?"
                    {...input}
                    meta={meta}
                  />
                )}
              />
              <Button
                type="submit"
                size="maxWidth"
                increased
                className={styles.reviewBtn}
              >
                Оставить отзыв
              </Button>
            </form>
          );
        }}
      />
    </div>
  );
};

export default Review;
