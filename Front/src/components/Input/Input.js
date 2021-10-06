import React from "react";
import cn from "classnames";
import PropTypes from "prop-types";
import styles from "./Input.module.scss";

const Input = ({ className, size, ...rest }) => {
  const inputClassNames = cn(styles.input, {
    [className]: Boolean(className),
    [styles[size]]: Boolean(size),
  });
  return <input className={inputClassNames} {...rest} />;
};

Input.defaultProps = {
  className: null,
  size: "standart",
};

Input.propTypes = {
  className: PropTypes.string,
  size: PropTypes.string,
};

export default Input;
