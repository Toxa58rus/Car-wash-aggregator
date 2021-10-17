import React from "react";
import cn from "classnames";
import PropTypes from "prop-types";

import Button from "../Button/Button";
import styles from "./Tabs.module.scss";

const Tab = (props) => {
  const { label, id, onClick, activeTab, className } = props;

  const handleClick = () => {
    if (id) return onClick(id);

    return onClick(label);
  };

  const tabClassNames = cn(styles.tabBtn, {
    [styles.tabBtnActive]: activeTab === id || activeTab === label,
    [className]: Boolean(className),
  });

  return (
    <Button className={tabClassNames} onClick={handleClick}>
      {label}
    </Button>
  );
};

Tab.defaultProps = {
  id: null,
  className: null,
};

Tab.propTypes = {
  activeTab: PropTypes.oneOfType([PropTypes.string, PropTypes.number])
    .isRequired,
  label: PropTypes.string.isRequired,
  onClick: PropTypes.func.isRequired,
  id: PropTypes.number,
  className: PropTypes.string,
};

export default Tab;
