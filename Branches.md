# Branches in Movies Microservice

Describes how we branch work in this repository.

Contents

1.  Overview of deployment strategy
2.  The main branch
3.  Branch groups
4.  Branch naming convention
5.  Development

## Overview of deployment strategy

Deployment are done on `release` sub-branches.
What this means is that any code merged into these branches are deemed production ready.
CI/CD pipelines will pick up

The current roadmap for release sub-branches are as follows:

movie-v1        -- The application running Angular 17 and Orleans 3 and .NET Core 3.1
movie-v1-secure -- The version of app31 with updated libraries that do not have vulnerable libraries
movie-v2        -- The application running Angular 17 and Orleans 7 and .NET Core 3.1


## The main branch

The `main` branch is a rolling development trunk of the application.
It holds the the latest and greatest version of the code.
For example, given the `movie-v2` release branch we have above, 
this would implied that any work merged into main would potentially be featured into `movie-v3` release branch


## Branch groups

Branches should be grouped using the following

feature -- new features
bugfix  -- bugs
release -- releases


Why no nnnnn branch? 

    Where nnnnn is:

    hotfix  -- use bugfix
    dev     -- use feature
    docs    -- use feature


## Branch naming convention

Other than the `main` branch and `release` branches, all other branches should be named in the following convention:

`<group-name>/<release-name>/<branch-name>`

Examples:

```
feature/movie-v1/containerization
feature/movie-v1/use-adonet-provider
feature/main/add-test-doc
bugfix/movie-v1/fix-log
bugfix/movie-v1/fix-formatting
bugfix/main/correct-user-doc
```

Naming convention for `release` branches are as follows:

`release/<release-name>`

Examples:

```
release/movie-v1
release/movie-v1-secure
release/movie-v2
```

## Development strategy

Development work should be release-oriented.
That is to say, whatever work we are doing, we should know which release its intended for.

Hence to develop a new feature or bugfix, first decide which release is the new code going to go to first.

For example, I decide to work on a feature call `use-adonet-provider` for the `movie-v1`
I would create a branch `feature/movie-v1/use-adonet-provider`
I would do all work on this branch.
When I'm done, I would merge this code into the `release/movie-v1` branch.
