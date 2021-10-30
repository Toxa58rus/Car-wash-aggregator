import React, { useEffect, useState } from "react";
import Button from "../../Button/Button";
import WashCard from "../../WashCard/WashCard";
import Modal from "../../Modal/Modal";
import AddCarWash from "../../AddCarWash/AddCarWash";
import styles from "./ProfilePage.module.scss";
import api from "../../../lib/api";
import sources from "../../../helpers/sources";
import { useDispatch, useSelector } from "react-redux";
import { selectSession, setSession } from "../../../state/session";
import Spinner from "../../Spinner/Spinner";
import { toast } from "react-toastify";

const ProfileCarWashes = () => {
  const [modalIsOpen, toggleModal] = useState(false);
  const [state, setState] = useState({ data: null, isLoading: true });
  const session = useSelector(selectSession);
  const dispatch = useDispatch();

  const getCarWashList = () => {
    api
      .get(sources.carWashList(session.id))
      .then((response) => {
        setState({ data: response.data, isLoading: false });

        if (response.user) {
          dispatch(setSession(response.user));
        }
      })
      .catch(() => toast.error("Error"));
  };

  useEffect(() => {
    if (state.isLoading) {
      getCarWashList();
    }
  });

  const closeAddWashModal = () => {
    toggleModal(false);
  };

  const openAddWashModal = () => {
    toggleModal(true);
  };

  return (
    <div className={styles.contain}>
      {modalIsOpen && (
        <Modal onClose={closeAddWashModal} label="Добавить мойку">
          <AddCarWash
            getCarWashList={getCarWashList}
            onClose={closeAddWashModal}
          />
        </Modal>
      )}
      <Button
        className={styles.addWashBtn}
        onClick={openAddWashModal}
        increased
      >
        Добавить мойку
      </Button>
      {state.isLoading ? (
        <Spinner center />
      ) : (
        state.data.carWashes.map((item) => (
          <div className={styles.washCard} key={item.id}>
            <WashCard id={item.id} item={item} />
          </div>
        ))
      )}
    </div>
  );
};

export default ProfileCarWashes;
