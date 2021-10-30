import React, { useState } from "react";
import ImageUploading from "react-images-uploading";

import addImgIcon from "../../icons/add-photo.svg";

import Button from "../Button/Button";
import styles from "./AddPhoto.module.scss";

const AddPhoto = ({ formChange }) => {
  const [image, setImages] = useState([]);
  const maxNumber = 1;

  const onChange = (imageList, addUpdateIndex) => {
    setImages(imageList);
    formChange(imageList[0]);
  };

  const handleClick = (addImage, removeImage) => {
    if (image.length === 1) {
      removeImage();
      addImage();
    } else {
      addImage();
    }
  };

  return (
    <div className={styles.contain}>
      <ImageUploading
        value={image}
        onChange={onChange}
        maxNumber={maxNumber}
        dataURLKey="data_url"
      >
        {({ imageList, onImageUpload, onImageRemoveAll, dragProps }) => (
          <div className={styles.imgWrap}>
            <Button
              onClick={() => handleClick(onImageUpload, onImageRemoveAll)}
              className={styles.addImgBtn}
              {...dragProps}
            >
              <img src={addImgIcon} alt="addd Img Icon" />
            </Button>
            {imageList.map((image, index) => (
              <div key={index} className="image-item">
                <img src={image["data_url"]} alt="img" />
              </div>
            ))}
          </div>
        )}
      </ImageUploading>
    </div>
  );
};

export default AddPhoto;
