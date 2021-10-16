import React from "react";
import cn from "classnames";
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

export default Tab;
