import React from "react";
import cn from "classnames";
import PropTypes from "prop-types";
import ReactSelect from "react-select";
import SelectOtion from "./SelectOption";
import styles from "./Select.module.scss";

const Select = (props) => {
  const {
    options,
    defaultValue,
    placeholder,
    meta,
    transparent,
    isMulti,
    ...rest
  } = props;

  const containerCn = cn(styles.contain, {
    [styles.error]: meta && (meta.error || meta.submitError) && meta.touched,
    [styles.transparent]: Boolean(transparent),
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
        isMulti={isMulti}
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
  transparent: null,
  isMulti: false,
};

Select.propTypes = {
  options: PropTypes.arrayOf(PropTypes.object).isRequired,
  defaultValue: PropTypes.objectOf(PropTypes.string),
  placeholder: PropTypes.string.isRequired,
  meta: PropTypes.oneOfType([PropTypes.object, PropTypes.bool]),
  transparent: PropTypes.bool,
  isMulti: PropTypes.bool,
};

export default Select;
