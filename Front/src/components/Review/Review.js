import React, { useState } from "react";
import { Form, Field } from "react-final-form";

import RateStars from "../RateStars/RateStars";
import Button from "../Button/Button";
import styles from "./Review.module.scss";

const Review = () => {
  const [rate, setRate] = useState();

  const handleRateChange = (value) => {
    setRate(value);
  };

  const sendReview = () => {};

  return (
    <div className={styles.contain}>
      <div className={styles.title}>Оставте свой отзыв</div>
      <Form
        onSubmit={sendReview}
        render={({ handleSubmit, form }) => (
          <form onSubmit={handleSubmit}>
            <div className={styles.inner}>
              <Field
                name="rate"
                render={({ input, meta }) => {
                  form.change("rate", rate);
                  return (
                    <div className={styles.rate}>
                      <RateStars
                        {...input}
                        meta={meta}
                        size={40}
                        onChange={handleRateChange}
                      />
                      <span>Оцените это заведение *</span>
                    </div>
                  );
                }}
              />
            </div>
            <Field
              name="description"
              render={({ input, meta }) => (
                <textarea
                  className={styles.textarea}
                  placeholder="Чтыбы вы хотели рассказать о данном заведении?"
                  {...input}
                  meta={meta}
                />
              )}
            />
            <Button type="submit" size="maxWidth" className={styles.reviewBtn}>
              Оставить отзыв
            </Button>
          </form>
        )}
      />
    </div>
  );
};

export default Review;
