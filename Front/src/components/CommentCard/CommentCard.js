import React from "react";

import userIcon from "../../icons/person.svg";

import RateStars from "../RateStars/RateStars";
import styles from "./CommentCard.module.scss";

const CommentCard = () => {
  return (
    <div className={styles.contain}>
      <div className={styles.inner}>
        <div className={styles.user}>
          <img src={userIcon} alt="user" />
          <div className={styles.userInfo}>
            <div>UserName</div>
            <span>comment date</span>
          </div>
        </div>
        <div>
          <RateStars edit={false} />
        </div>
      </div>
      <div className={styles.text}>
        The watermelon taste is so refreshing. You can feel the produced effect
        in half an hour or so. It doesn’t get you relaxed as fast as vapes, but
        you can take these lollipops anywhere without getting the looks.
      </div>
    </div>
  );
};

export default CommentCard;
