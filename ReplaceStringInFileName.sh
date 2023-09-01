#!/bin/bash

OWN_PATH=$(dirname "$(realpath $0)")
OWN_NAME=$0

LOG_PATH=$OWN_PATH
LOG_FILE=${OWN_NAME%.*}.log

clear

echo `date +%Y%m%d_%H%M%S`">*                      *                                                    *"| tee -a $LOG_PATH/$LOG_FILE
echo `date +%Y%m%d_%H%M%S`">*******************************************************************************"| tee -a $LOG_PATH/$LOG_FILE
echo `date +%Y%m%d_%H%M%S`">  - running script - $OWN_NAME - -  "| tee -a $LOG_PATH/$LOG_FILE
echo `date +%Y%m%d_%H%M%S`">*******************************************************************************"| tee -a $LOG_PATH/$LOG_FILE


PTH="$OWN_PATH"

SRCH="*.notesGETFTP*"


echo `date +%Y%m%d_%H%M%S`"> PTH=$PTH " | tee -a $LOG_PATH/$LOG_FILE
echo `date +%Y%m%d_%H%M%S`"> SRCH=$SRCH " | tee -a $LOG_PATH/$LOG_FILE

#filesNames=$(grep -lR -i $SRCH $PTH )
filesNames=$(ls $SRCH )


#greeting="Hello, John Doe!"
#new_greeting="${greeting/John/Jane}"
#echo $new_greeting | tee -a $LOG_PATH/$LOG_FILE

for f in $filesNames;
do
	echo `date +%Y%m%d_%H%M%S`"> -------------------- "| tee -a $LOG_PATH/$LOG_FILE
	echo `date +%Y%m%d_%H%M%S`"> $f"| tee -a $LOG_PATH/$LOG_FILE
	
	nwFileNm="${f/fileS./}"
	nwFileNm="${nwFileNm/.ABC./}"
	nwFileNm="${nwFileNm/notesGETFTP/newFileName}"
	echo `date +%Y%m%d_%H%M%S`"> $nwFileNm"| tee -a $LOG_PATH/$LOG_FILE

 	mv $f $nwFileNm
done

echo `date +%Y%m%d_%H%M%S`"> |||||||||||||||||||||||||||||||| " | tee -a $LOG_PATH/$LOG_FILE
echo `date +%Y%m%d_%H%M%S`"> DONE! " | tee -a $LOG_PATH/$LOG_FILE
