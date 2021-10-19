import React, { useState } from "react";
import Tab from "./Tab";
import PropTypes from "prop-types";
import styles from "./Tabs.module.scss";

const Tabs = (props) => {
  const { tabsRenderer, children, selected, onChangeTab, tabs, onlyChildren } =
    props;

    const [state, setState] = useState({
      activeTab: selected || children[0].props.label,
    });

    const onClickTabItem = (tab) => {
      setState({ activeTab: tab });

      if (onChangeTab) onChangeTab(tab);
    };

    return (
      <div className={styles.tabs}>
        <div className={styles.tabsWrap}>
          <div className={styles.inner}>
            {tabsRenderer
              ? tabsRenderer(tabs || children, state.activeTab, onClickTabItem)
              : children.map((child) => {
                  const { label } = child.props;

                  return (
                    <Tab
                      activeTab={state.activeTab}
                      key={label}
                      label={label}
                      onClick={onClickTabItem}
                    />
                  );
                })}
          </div>
        </div>
        <div className={styles.tabContent}>
          {onlyChildren
            ? children
            : children.map((child) => {
                if (!child) return null;
                if (child.props.label !== state.activeTab) return null;
                return child.props.children;
              })}
        </div>
      </div>
    );
};

Tabs.defaultProps = {
  className: null,
  tabsRenderer: null,
  onlyChildren: false,
  onChangeTab: null,
  selected: null,
  tabs: null,
};

Tabs.propTypes = {
  className: PropTypes.string,
  children: PropTypes.oneOfType([PropTypes.array, PropTypes.object]).isRequired,
  tabsRenderer: PropTypes.func,
  onlyChildren: PropTypes.bool,
  onChangeTab: PropTypes.func,
  selected: PropTypes.number,
  tabs: PropTypes.arrayOf(PropTypes.object),
};

export default Tabs;
