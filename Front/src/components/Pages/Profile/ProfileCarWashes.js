import React, { useState } from "react";
import Button from "../../Button/Button";
import WashCard from "../../WashCard/WashCard";
import Modal from "../../Modal/Modal";
import AddCarWash from "../../AddCarWash/AddCarWash";
import styles from "./ProfilePage.module.scss";

const WASHES = [
  {
    id: 1,
    name: "Aplle",
    description:
      "Автомойка Апельсин предоставляет широкий спектор услуг по уборке вашего автомобиля",
    adress: "ADdress",
    availability: 4,
    category: ["B", "C"],
  },
  {
    id: 2,
    name: "Aplle",
    description:
      "Автомойка Апельсин предоставляет широкий спектор услуг по уборке вашего автомобиля",
    adress: "ADdress",
    availability: 4,
    category: ["B", "C"],
  },
  {
    id: 3,
    name: "Aplle",
    description:
      "Автомойка Апельсин предоставляет широкий спектор услуг по уборке вашего автомобиля",
    adress: "ADdress",
    availability: 4,
    category: ["B", "C"],
  },
  {
    id: 4,
    name: "Aplle",
    description:
      "Автомойка Апельсин предоставляет широкий спектор услуг по уборке вашего автомобиля",
    adress: "ADdress",
    availability: 4,
    category: ["B", "C"],
  },
];

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
        <Modal onClose={closeReviewModal} label="Оставте свой отзыв">
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
