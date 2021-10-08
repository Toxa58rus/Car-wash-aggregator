import React from "react";
import cn from "classnames";
import styles from "./Select.module.scss";

const SelectOtion = (props) => {
  const { children, isDisabled, isFocused, innerProps } = props;

  const className = cn(styles.option, {
    [styles.focused]: isFocused,
    [styles.disabled]: isDisabled,
  });
  return (
    <div className={className} {...innerProps}>
      <div className={styles.value}>{children}</div>
      <div className={styles.status}>{!isDisabled ? "Свободно" : "Занято"}</div>
    </div>
  );
};

export default SelectOtion;
