import { ApplicationConfig, importProvidersFrom } from '@angular/core';
import { provideRouter } from '@angular/router';

import { routes } from './app.routes';
import { HttpClientModule, provideHttpClient, withFetch } from '@angular/common/http';
import { provideAnimations } from '@angular/platform-browser/animations';
import { graphqlProvider } from './graphql.provider';

export const appConfig: ApplicationConfig = {
    providers: [
        provideRouter(
            routes 
            //,  withDebugTracing()
        )
        , importProvidersFrom(HttpClientModule)
        , provideHttpClient(withFetch())
        , provideAnimations()
        , provideHttpClient()
        , graphqlProvider
    ]
};
