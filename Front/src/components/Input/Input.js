import React from "react";
import cn from "classnames";
import PropTypes from "prop-types";
import styles from "./Input.module.scss";

const Input = ({ className, size, meta, ...rest }) => {
  const inputClassNames = cn(styles.input, {
    [className]: Boolean(className),
    [styles[size]]: Boolean(size),
    [styles.error]: meta && (meta.error || meta.submitError) && meta.touched,
  });

  return (
    <div className={styles.container}>
      {meta && (meta.error || meta.submitError) && meta.touched && (
        <div className={styles.label}>{meta.error}</div>
      )}
      <input className={inputClassNames} {...rest} />
    </div>
  );
};

Input.defaultProps = {
  className: null,
  size: "standart",
  meta: null,
};

Input.propTypes = {
  className: PropTypes.string,
  size: PropTypes.string,
  meta: PropTypes.oneOfType([PropTypes.object, PropTypes.bool]),
};

export default Input;
