import React, { useEffect } from "react";
import cn from "classnames";
import PropTypes from "prop-types";
import Portal from "../Portal/Portal";

import backIcon from "../../icons/arrow-left.svg";
import closeIcon from "../../icons/close-small.svg";

import Button from "../Button/Button";
import styles from "./Modal.module.scss";

const Modal = (props) => {
  const { children, className, onClose, size, label } = props;
  const modalClassName = cn(styles.modal, {
    [styles.className]: Boolean(className),
    [styles[size]]: Boolean(size),
  });

  const handleKeyUp = (event) => {
    if (event.keyCode === 27) {
      onClose();
    }
  };

  useEffect(() => {
    document.body.style.overflow = "hidden";
    document.addEventListener("keyup", handleKeyUp);

    return () => {
      document.body.removeAttribute("style");
      document.removeEventListener("keyup", handleKeyUp);
    };
  });

  const preventClick = (event) => {
    event.stopPropagation();
  };

  return (
    <Portal>
      <div className={styles.modalOverlay} onClick={onClose}>
        <div className={modalClassName} onClick={preventClick}>
          <Button size="icon" className={styles.cancelBtn} onClick={onClose}>
            <img src={closeIcon} alt="close modal" />
          </Button>
          <Button className={styles.backBtn} onClick={onClose} size="maxWidth">
            <div>
              <img src={backIcon} alt="close modal" />
              {label}
            </div>
          </Button>
          {children}
        </div>
      </div>
    </Portal>
  );
};

Modal.defaultProps = {
  size: "sm",
  className: null,
  label: null,
};

Modal.propTypes = {
  size: PropTypes.oneOf(["sm", "xs", "small"]),
  children: PropTypes.arrayOf(PropTypes.element).isRequired,
  className: PropTypes.string,
  onClose: PropTypes.func.isRequired,
  label: PropTypes.string,
};

export default Modal;
