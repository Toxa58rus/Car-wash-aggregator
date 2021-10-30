import React from "react";
import Stars from "react-rating-stars-component";
import PropTypes from "prop-types";

const RateStars = (props) => {
  const { onChange, value, size, edit } = props;

  const isNumber = (value) => {
    if (typeof value === "string") {
      const arr = value.split(",");
      const str = arr.join(".");
      return +str;
    } else {
      return value;
    }
  };

  return (
    <div>
      <Stars
        count={5}
        value={isNumber(value)}
        onChange={onChange}
        isHalf={true}
        size={size}
        edit={edit}
      />
    </div>
  );
};

RateStars.defaultProps = {
  value: null,
  size: 25,
  edit: true,
  onChange: null,
};

RateStars.propTypes = {
  onChange: PropTypes.func,
  value: PropTypes.oneOfType(PropTypes.string, PropTypes.number),
  size: PropTypes.number,
  edit: PropTypes.bool,
};

export default RateStars;
