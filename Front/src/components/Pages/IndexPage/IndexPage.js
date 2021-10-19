import React, {useState, useEffect} from "react";
import Header from "../../Header/Header";
import { Form, Field } from "react-final-form";
import sources from '../../../helpers/sources';

import MapMark from "../../../icons/Vector.svg";
import downArrow from "../../../icons/downArrow.svg";
import Clock from "../../../icons/Clock.svg";

import WashCard from "../../WashCard/WashCard";
import Button from "../../Button/Button";
import Input from "../../Input/Input";
import DateForm from "../../DateForm/DateForm";
import { TIME_FIELDS } from "../../../constants/TIME-FIELDS";
import { getDate } from "../../../helpers/dateFormatter";
import Select from "../../Select/Select";
import styles from "./IndexPage.module.scss";

const IndexPage = () => {

  const [calendarIsOpen, setCalendar] = useState(false);
  const [state, setState] = useState({
    washes: []
  });

  const sendData = async (data) => { //Функция отправки данных на сервер тут энд поинт для поиска
      data = JSON.stringify(data);
      /*if (!response.ok){
        throw new Error (`Ошибка по адресу ${url}, Статус ошибки ${response.status}`);
      }*/
  }

  const getData = async (data) => { //Функция получения данных с сервера
    // api.get(sources.search, { params: {...data}}).then((response) => setState({washes: response.data}))
    // await fetch (url) // получение данных с сервера
    // .then(response => response.json())
    // .then(
    //   (result) => {
    //       this.setState(
    //           {
    //             washes: result.washes //занесение всех элменетов в массив
    //           }
    //       )
    //   }
    // )
  }

  let currentForm =null;
  const handleOpenCalendar = (event) => {
    event.stopPropagation();
    setCalendar(true);
  };
  const handleCloseCalendar = () => {
    setCalendar(false);
  };
  const setValue = (date) => {
    currentForm.change("date", date);
    setCalendar(false);
    console.log(date);
  }

    const initialValues = { date: getDate(new Date()) };
    return (    
      <div>
        <Header />
        <div className={styles.washSearch}>
          <div className={styles.searchUpperBlock}>
            <h2>Поиск моек</h2>
            <div className={styles.citySelect}>
              <img src={MapMark} alt="MapMark"/>
              <span className={styles.cityName} >Москва</span>
              <img src={downArrow} alt="downArrow" />
            </div>
          </div>
          <Form
            onSubmit={getData}
            initialValues={initialValues}
            render={({ handleSubmit, form, values }) => {
              currentForm = form;
              return (
                <form>  
                  <div className={styles.searchBlock} onClick={handleCloseCalendar}>
                    <span className={styles.blockStr}>Выберите конкретную дату и время</span>
                    <div className={styles.innerBlock} >            
                      <div className={styles.innerBlockDate} onClick={handleOpenCalendar}>
                        <Field name="date">
                          {({ input, meta }) =>  (
                              <DateForm                              
                                calendarIsOpen={calendarIsOpen}
                                setValue={setValue}
                                meta={meta}
                                {...input}
                              />
                          )}
                        </Field>  
                      </div>
                      <div className={styles.innerBlockDate}>
                        <img src={Clock} alt="Clock"/>
                        <Field name="Time"
                          render={({ input, meta }) => (
                            <Select
                              placeholder="Время *"
                              options={TIME_FIELDS}
                              meta={meta}
                              {...input}
                            />
                          )}
                        />
                      </div>
                      <Button
                        type="submit" 
                        className={styles.innerBlockButton}
                      >
                        Подобрать мойку
                      </Button>
                    </div>
                  </div>
                  <div className={styles.searchBlock}>
                    <span className={styles.blockStr}>Или воспользуйтесь поиском</span>
                    <Field name="Text"
                      render={({ input, meta }) => (
                        <Input
                          className={styles.searchBlockInput}
                          placeholder="Поиск по названию, адресу, услуге"
                          meta={meta}
                          {...input}
                        />
                      )}      
                    />
                    <div className={styles.nearestWash}>
                      <img src={MapMark} alt="MapMark"/>
                      <span className={styles.nearestWashLink}>Рядом со мной</span>
                    </div>          
                  </div>
                </form>
              );
            }}    
          />    
        </div>
        <h2 className={styles.cityWashes}>Мойки в Москве</h2>
        <div className={styles.washList}> 
          {/*washes.map(wash=>(
            <WashCard
              id = {wash.id} 
              name={wash.name}
              desc={wash.description}
              adress={wash.adress}
              pic={wash.picture}
              availability={wash.availability}
              category={wash.category}
            />
          ))*/}
        </div>
      </div>
    )
}  

export default IndexPage;
