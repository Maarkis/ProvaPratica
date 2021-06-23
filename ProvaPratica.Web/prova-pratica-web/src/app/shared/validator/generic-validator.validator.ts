import {AbstractControl, FormArray, FormControl, FormGroup, ValidationErrors, ValidatorFn} from '@angular/forms';


export class GenericValidator {
    constructor() {
    }


    // Verifica validação dos campos
    static verifierValidatorsForm(formGroup: FormGroup) {
        Object.keys(formGroup.controls).forEach(campoControls => {
            const control = formGroup.get(campoControls);
            if(control){
                control.markAsDirty();
                control.markAsTouched();

                if (control instanceof FormGroup) {
                    this.verifierValidatorsForm(control);
                }
            }
        });
    }


}
