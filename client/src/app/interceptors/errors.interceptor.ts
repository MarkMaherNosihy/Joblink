import { HttpEvent, HttpInterceptorFn } from '@angular/common/http';
import { inject } from '@angular/core';
import { NavigationExtras, Router } from '@angular/router';
import { Observable, catchError } from 'rxjs';
import { ToastService } from '../services/ui/toast.service';

export const errorsInterceptor: HttpInterceptorFn = (req, next) => {
  const router = inject(Router);
  const toast = inject(ToastService);
  return next(req).pipe(
    catchError((err)=>{
      if(err){
        switch(err.status){
          case 400:
            if(err.error.errors){
              const modelStateErrors = [];

              for(const key in err.error.errors){
                if(err.error.errors[key]) modelStateErrors.push(err.error.errors[key]);
              }
              throw modelStateErrors.flat();
            }else{
              console.log("an error has occured!");
            }
            break;
          case 401:
            toast.show("Unauthorized", "You are trying to access an unauthorized route.", 'danger')
            break;
          case 404:
            router.navigateByUrl('not-found');
            break;
          case 500:
            const navExtras: NavigationExtras = {state: {error: err.error}};
            router.navigateByUrl('server-error', navExtras);
            break;
          default:
            toast.show("Something has occured", "An error has occured please try again later.", 'danger');
            break; 
        }
      }
      throw err;
    })
  );
};
