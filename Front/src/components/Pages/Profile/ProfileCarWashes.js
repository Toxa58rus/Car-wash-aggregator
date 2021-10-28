import React, { useState } from "react";
import WASHES from "../../../constants/WASHES";
import Button from "../../Button/Button";
import WashCard from "../../WashCard/WashCard";
import Modal from "../../Modal/Modal";
import AddCarWash from "../../AddCarWash/AddCarWash";
import styles from "./ProfilePage.module.scss";

const ProfileCarWashes = () => {
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
        <Modal onClose={closeReviewModal} label="Добавить мойку">
          <AddCarWash />
        </Modal>
      )}
      <Button className={styles.addWashBtn} onClick={openReviewModal} increased>
        Добавить мойку
      </Button>
      {WASHES.map((item) => (
        <div className={styles.washCard} key={item.id}>
          <WashCard id={item.id} item={item} />
        </div>
      ))}
    </div>
  );
};

export default ProfileCarWashes;
