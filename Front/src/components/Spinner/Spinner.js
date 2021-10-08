import React from 'react';
import PropTypes from 'prop-types';
import cn from 'classnames';
import styles from './Spinner.module.scss';

const Spinner = ({ size, variant, center }) => {
  const className = cn(styles.spinner, {
    [styles[variant]]: !!variant,
  });
  const containerClassName = cn({
    [styles.center]: center,
  });

  return (
    <div className={containerClassName}>
      <div style={{ fontSize: size }} className={className} />
    </div>
  );
};

Spinner.defaultProps = {
  size: 2,
  variant: null,
  center: false,
};

Spinner.propTypes = {
  size: PropTypes.number,
  variant: PropTypes.oneOf(['black', 'white']),
  center: PropTypes.bool,
};

export default Spinner;
