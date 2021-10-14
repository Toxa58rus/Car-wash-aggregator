import React from "react";
import cn from "classnames";
import PropTypes from "prop-types";
import ReactSelect from "react-select";
import SelectOtion from "./SelectOption";
import styles from "./Select.module.scss";

const Select = ({ options, defaultValue, placeholder, meta, ...rest }) => {
  const containerCn = cn(styles.contain, {
    [styles.error]: meta && (meta.error || meta.submitError) && meta.touched,
  });

  return (
    <div className={containerCn}>
      {meta && (meta.error || meta.submitError) && meta.touched && (
        <div className={styles.label}>{meta.error}</div>
      )}
      <ReactSelect
        classNamePrefix="select"
        placeholder={placeholder}
        options={options}
        defaultValue={defaultValue}
        isOptionDisabled={(option) => option.status === "Booked"}
        getOptionLabel={(option) => option.name}
        getOptionValue={(option) => option.id}
        components={{
          Option: SelectOtion,
        }}
        {...rest}
      />
    </div>
  );
};

Select.defaultProps = {
  defaultValue: null,
  meta: null,
};

Select.propTypes = {
  options: PropTypes.arrayOf(PropTypes.object).isRequired,
  defaultValue: PropTypes.shape(),
  placeholder: PropTypes.string.isRequired,
  meta: PropTypes.oneOfType([PropTypes.object, PropTypes.bool]),
};

export default Select;
