import React, { useEffect, useState } from "react";
import sources from "../../helpers/sources";
import { toast } from "react-toastify";

import userIcon from "../../icons/person.svg";
import api from "../../lib/api";

import RateStars from "../RateStars/RateStars";
import Spinner from "../Spinner/Spinner";
import styles from "./CommentCard.module.scss";

const CommentCard = ({ comment }) => {
  const { rating, message, userId } = comment;
  const [state, setState] = useState({ user: null, isLoading: true });

  const getUser = () => {
    api
      .get(sources.users(userId))
      .then((response) => {
        setState({ user: response.data, isLoading: false });
      })
      .catch((err) => toast.error("User error"));
  };

  useEffect(() => {
    if (state.isLoading) {
      getUser();
    }
  });

  return (
    <div className={styles.contain}>
      {state.isLoading ? (
        <Spinner center />
      ) : (
        <>
          <div className={styles.inner}>
            <div className={styles.user}>
              <img src={userIcon} alt="user" />
              <div className={styles.userInfo}>
                {state.user.firstName} {state.user.lastName}
              </div>
            </div>
            <div>
              <RateStars edit={false} value={rating} />
            </div>
          </div>
          {message && <div className={styles.text}>{message}</div>}
        </>
      )}
    </div>
  );
};

export default CommentCard;
