import React from "react";
import Stars from "react-rating-stars-component";
import PropTypes from "prop-types";

const RateStars = (props) => {
  const { onChange, value, size, edit } = props;

  return (
    <div>
      <Stars
        count={5}
        value={value}
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
};

RateStars.propTypes = {
  onChange: PropTypes.func.isRequired,
  value: PropTypes.number,
  size: PropTypes.number,
  edit: PropTypes.bool,
};

export default RateStars;
