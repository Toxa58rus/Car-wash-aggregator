import React from "react";
import PropTypes from "prop-types";
import cn from "classnames";

import styles from "./Button.module.scss";

const Button = (props) => {
  const { children, onClick, className, size } = props;

  const btnCN = cn(styles.button, {
    [styles[size]]: Boolean(size),
    [className]: Boolean(className),
  });

  return (
    <button onClick={onClick} className={btnCN}>
      {children}
    </button>
  );
};

Button.defaultProps = {
  size: "standart",
  onClick: null,
  className: null,
};

Button.propTypes = {
  onClick: PropTypes.func,
  className: PropTypes.string,
  children: PropTypes.oneOfType([
    PropTypes.string,
    PropTypes.array,
    PropTypes.element,
  ]).isRequired,
  size: PropTypes.oneOf(["standart", "maxWidth"]),
};

export default Button;
