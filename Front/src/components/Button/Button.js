import React from "react";
import PropTypes from "prop-types";
import cn from "classnames";

import styles from "./Button.module.scss";

const Button = (props) => {
  const { children, onClick, className, size, type, ...rest } = props;

  const btnCN = cn(styles.button, {
    [styles[size]]: Boolean(size),
    [className]: Boolean(className),
  });

  return (
    <button onClick={onClick} className={btnCN} type={type} {...rest}>
      {children}
    </button>
  );
};

Button.defaultProps = {
  size: "standart",
  onClick: null,
  className: null,
  type: "button",
};

Button.propTypes = {
  onClick: PropTypes.func,
  className: PropTypes.string,
  children: PropTypes.oneOfType([
    PropTypes.string,
    PropTypes.array,
    PropTypes.element,
  ]).isRequired,
  type: PropTypes.string,
  size: PropTypes.oneOf(["standart", "maxWidth", "content"]),
};

export default Button;
