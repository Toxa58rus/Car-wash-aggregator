import React from "react";
import cn from "classnames";
import PropTypes from "prop-types";
import styles from "./Select.module.scss";

const SelectOption = (props) => {
  const { children, isDisabled, isFocused, innerProps, data } = props;

  const className = cn(styles.option, {
    [styles.focused]: isFocused,
    [styles.disabled]: isDisabled,
  });
  return (
    <div className={className} {...innerProps}>
      <div className={styles.value}>{children}</div>
      <div className={styles.status}>
        {data.status && (!isDisabled ? "Свободно" : "Занято")}
      </div>
    </div>
  );
};

SelectOption.defaultProps = {
  data: null,
};

SelectOption.propTypes = {
  isFocused: PropTypes.bool.isRequired,
  children: PropTypes.oneOfType([PropTypes.string, PropTypes.element])
    .isRequired,
  innerProps: PropTypes.shape().isRequired,
  data: PropTypes.shape({
    data: PropTypes.shape(),
  }),
  isDisabled: PropTypes.bool.isRequired,
};

export default SelectOption;
