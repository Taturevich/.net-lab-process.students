# Task workflow
* Create branch `task-#` (where "#" symbol is the number of the task e.g. task-1) from `develop` branch;
```

           | 
           |
          / task-#
         /
        |
        |
        |
develop |

```
* Commit and Push changes to this branch at least twice a week;
* Every commit has to have adequate description (Examples: "Implement repositry for Event", "Fix unit tests");
* After work on your task is done, merge branch `task-#` back to `develop` and add tag `task-#` to `develop` branch. Then delete `task-#` branch;
```
        |
        |[task-#]
         \
          \
           |       
           | 
           |
          / task-#
         /
        |
        |
        |
develop |

```

* Open PR to `master` branch using [pull_request_template](https://bitbucket.org/andrey_koshevoy/epam.net_training/src/master/docs/pull_request_template.md);
* Fix ongoing issues that your reviewer opened by commiting fixes to `develop` branch;

# Issue workflow
* All issues with priority higher than `minor` should be resolved before PR to `master` opened;
* Don't close issues. This will be done by reviwer after he will ensure that issue was resolved; 

