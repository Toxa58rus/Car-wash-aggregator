import React from "react";
import PropTypes from "prop-types";
import cn from "classnames";

import styles from "./Button.module.scss";

const Button = (props) => {
  const { children, onClick, className, size, type, increased, ...rest } =
    props;

  const btnCN = cn(styles.button, {
    [styles[size]]: Boolean(size),
    [className]: Boolean(className),
    [styles.increased]: Boolean(increased),
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
  increased: null,
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
  size: PropTypes.oneOf(["standart", "maxWidth"]),
  increased: PropTypes.bool,
};

export default Button;
